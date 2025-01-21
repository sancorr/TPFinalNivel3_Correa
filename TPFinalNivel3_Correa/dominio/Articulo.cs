﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinalNivel3_Correa.dominio;
namespace dominio
{
    public class Articulo
    {
		public int Id { get; set; }
		public string Codigo { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public MarcaArticulo Marca { get; set; }
		public CategoriaArticulo Categoria { get; set; }
		public ArtFavorito Favorito { get; set; }
		public string ImagenUrl { get; set; }
		public decimal Precio { get; set; }
		public int IdMarca { get; set; }
		public int IdCategoria { get; set; }
	}
}
