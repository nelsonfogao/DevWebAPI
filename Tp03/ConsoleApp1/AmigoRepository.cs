using Dapper;
using Domain;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class AmigoRepository
    {
        private ProjetoContext Context { get; set; }

        public AmigoRepository(ProjetoContext context)
        {
            this.Context = context;
        }

        public IEnumerable<Amigo> GetAll()
        {
            return Context.Amigo.AsEnumerable();

        }

        public Amigo GetAmigoById(Guid id)
        {
            return Context.Amigo.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Amigo amigo)
        {
            this.Context.Amigo.Add(amigo);
            this.Context.SaveChanges();
        }

        public Amigo GetAmigoByEmail(string email)
        {
            return Context.Amigo.FirstOrDefault(x => x.Email == email);
        }

        public void Delete(Guid id)
        {
            var amigo = Context.Amigo.FirstOrDefault(x => x.Id == id);
            this.Context.Amigo.Remove(amigo);
            this.Context.SaveChanges();
        }

        public void Update(Guid id, Amigo amigo)
        {
            var amigoOld = Context.Amigo.FirstOrDefault(x => x.Id == id);

            amigoOld.Nome = amigo.Nome;
            amigoOld.Sobrenome = amigo.Sobrenome;
            amigoOld.Email = amigo.Email;
            amigoOld.Telefone = amigo.Telefone;
            amigoOld.DataDeAniversario = amigo.DataDeAniversario;
            amigoOld.Senha = amigo.Senha;

            Context.Amigo.Update(amigoOld);
            this.Context.SaveChanges();
        }
    }
}
