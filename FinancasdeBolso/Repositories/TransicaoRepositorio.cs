﻿using FinancasdeBolso.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasdeBolso.Repositories
{
    public class TransicaoRepositorio : ITransicaoRepositorio
    {
        private readonly LiteDatabase _database;
        private readonly string collectionName = "transacoes";
        public TransicaoRepositorio(LiteDatabase database)
        {
            _database = database;
        }

        public List<Transacao> GetAll()
        {
            return _database
                .GetCollection<Transacao>(collectionName)
                .Query()
                .OrderByDescending(a => a.Date)
                .ToList();
        }

        public void Add(Transacao transacao)
        {
            var colec = _database
                .GetCollection<Transacao>(collectionName);
            colec.Insert(transacao);
            colec.EnsureIndex(a => a.Date);
        }

        public void Update(Transacao transacao)
        {
            var colec = _database
                .GetCollection<Transacao>(collectionName);
            colec.Update(transacao);
        }

        public void Delete(Transacao transacao)
        {
            var colec = _database
                .GetCollection<Transacao>(collectionName);
            colec.Delete(transacao.Id);
        }

    }
}
