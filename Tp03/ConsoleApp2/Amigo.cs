using System;

namespace Domain
{
    public class Amigo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeAniversario { get; set; }

        public String Senha { get; set; }

    }
}
