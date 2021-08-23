using System;
using System.ComponentModel.DataAnnotations;

namespace Domain {
    public class Colaborador {
        [Key]
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome da mãe é obrigatório.")]
        [Display(Name = "Nome da Mãe")]
        [StringLength(80)]
        public string NomeMae { get; set; }

        [Display(Name = "Nome do Pai")]
        [StringLength(80)]
        public string NomePai { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(14)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Dias para Aniversário")]
        public int DiasParaAniversario = 0;
    }
}
