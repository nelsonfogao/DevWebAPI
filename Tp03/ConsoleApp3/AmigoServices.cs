using Domain;
using Repository;
using System;
using System.Collections.Generic;

namespace ApplicationService
{
    public class AmigoServices
    {
        private AmigoRepository Repository { get; set; }

        public AmigoServices(AmigoRepository repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Amigo> GetAll()
        {
            return Repository.GetAll();
        }

        public Amigo GetAmigoById(Guid id)
        {
            return Repository.GetAmigoById(id);
        }

        public void Save(Amigo amigo)
        {
            if (this.GetAmigoByEmail(amigo.Email) != null)
            {
                throw new Exception("Já existe um amigo com este email, por favor cadastre outro email");
            }

            this.Repository.Save(amigo);
        }

        public Amigo GetAmigoByEmail(string email)
        {
            return Repository.GetAmigoByEmail(email);
        }

        public void Delete(Guid id)
        {
            Repository.Delete(id);
        }

        public void Update(Guid id, Amigo amigo)
        {
            Repository.Update(id, amigo);
        }

    }
}
