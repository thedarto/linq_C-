// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

LinqQueries queries= new LinqQueries();
//toda la colección
//ImprimirValores(queries.TodaLaColeccion());

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

//Libros que tienen mas de 250 pag y tienen en el titulo la palabra in Action
//ImprimirValores(queries.LibrosConMasde250PagConPalabrasinAction());

//Todos los libros tienen status
//Console.WriteLine($"todos los libros tienene status:-{queries.TodosLosLibrosTienenStatus()}");

//Si algún libro fue publicado en 2005
//Console.WriteLine($"Algún libro fue publicado en 2005?:-{queries.SiAlgunLibroFuePublicado2005()}");

//Libros de Python
//ImprimirValores(queries.LibrosdePython());

//Libros de java ordenados por nombre
//ImprimirValores(queries.LibrosdeJavaPorNombreAscendente());

//Libros que tienen mas de 450 paginas ordenados por cantidad de paginas
//ImprimirValores(queries.LibrosDeMasDe450PagOrdenadosPorNumPagDes());

//tres libros de Java mas publicados recientemente
//ImprimirValores(queries.TresPrimerosLibrosOrdenadosPorFecha());

//tres libros de Java mas publicados recientemente
//ImprimirValores(queries.TerceryCuartoLibroDeMas400Pag());

//cantidad de libros que tienen entre 200 y 500 paginas
//ImprimirValores(queries.TresPrimerosLibrosDeLaColeccion());

//tres primeros libros filtrados con Select
Console.WriteLine($"Cantidad de libros que tiene entre 200 y 500 pag:{queries.CantidadDeLibrosEntre200y500Pag()}");


void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}\n","Titulo","N paginas","Fecha publicacion");
    foreach (var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}