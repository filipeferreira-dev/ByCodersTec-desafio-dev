﻿using Challenge.ApplicationService.Services.Contracts;
using Challenge.Domain.Enums;
using Challenge.Domain.Models;
using Challenge.Domain.Repositories;
using System.Globalization;

namespace Challenge.ApplicationService.Services
{
    public class ImporterApplicationService : IImporterApplicationService
    {
        IMerchantRepository MerchantRepository { get; }

        public ImporterApplicationService(IMerchantRepository merchantRepository)
        {
            MerchantRepository = merchantRepository;
        }

        public async Task ImportAsync(Stream file)
        {
            try
            {
                var merchants = ProcessFileAsync(file);
                await MerchantRepository.AddRangeAsync(merchants);
            }
            catch
            {
                //Aqui poderia ser aplicado algum tipo de log eu um retorno de com a mensagem de erro
                //para sem manipulado na controller e retorna uma bad request
                //Ou subir um excption personalizada que já será captura pelo middleware de exception
                //e retornar de lá uma mensagem para o usuário
            }
        }

        private IEnumerable<Merchant> ProcessFileAsync(Stream file)
        {
            var streamReader = new StreamReader(file);
            var line = streamReader.ReadLine();

            var merchants = new HashSet<Merchant>();

            while (line != null)
            {
                try
                {
                    var type = (TransactionTypeEnum)Convert.ToInt32(line.Substring(0, 1));
                    var date = line.Substring(1, 8);
                    var valor = Convert.ToDecimal(line.Substring(9, 10)) / 100;
                    var document = line.Substring(19, 11);
                    var card = line.Substring(30, 12);
                    var hora = line.Substring(42, 6);
                    var owner = line.Substring(48, 14).Trim();
                    var merchantName = line.Substring(62).Trim();

                    var hasMerchant = merchants.Any(m => m.Name == merchantName);

                    var merchant = hasMerchant ? merchants.First(m => m.Name == merchantName) : new Merchant(merchantName, owner);

                    var transaction = new Transaction(type, DateTime.ParseExact(date + hora, "yyyyMMddHHmmss", CultureInfo.InvariantCulture), valor, document, card);

                    merchant.AddTransaction(transaction);

                    if (!hasMerchant) merchants.Add(merchant);
                }
                finally
                {
                    line = streamReader.ReadLine();
                }
            }

            return merchants;
        }
    }
}
