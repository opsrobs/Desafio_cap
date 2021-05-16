using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proway_cap.Models
{
    [Table("Anuncio")]
    public class Anuncio_inv
    {
        
        
                                                                                                             
            [Key]     
            public int Id_anuncio { get; set; }            //Id da entidade
            [Column("nome_anuncio")]
            [StringLength(100)]
            [Required]
            public string Nome_anuncio { get; set; }        //atributo que recebe o nome do anuncio
            [Column("Cliente")]
            [StringLength(100)]
            [Required]
            public string Nome_cliente { get; set; }        //atributo que recebe o nome do cliente
            public DateTime Data_inicio { get; set; }       //atributo que recebe a data do inicio do investimento
            public DateTime Data_fim { get; set; }          //atributo que recebe a data final do investimento
            [Column("Valor")]
            [Required]
            public float Valor_investido { get; set; }      //atributo que recebe o valor investido
        
    }
}
