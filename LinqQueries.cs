public class LinqQueries
{
    private List<Book> librosCollection=new  List<Book>();
    public LinqQueries ()
    {
        using(StreamReader reader=new StreamReader("books.json"))
        {
            string json= reader.ReadToEnd();
            this.librosCollection=System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive=true});
        }
    }
    public IEnumerable<Book>TodaLaColeccion()
    {
        return librosCollection;
    }
    //***OPERADORES BÄSICOS
    //operador where para realizar búsquedas
    public IEnumerable <Book> LibrosDespuesdel2000()
    {
        //extension method
        //return librosCollection.Where(p=>p.PublishedDate.Year>2000);

        //query expresion
        return from l in librosCollection where l.PublishedDate.Year >2000 select l;
    }
    //Where filtra datos de una coleccion
    public IEnumerable <Book> LibrosConMasde250PagConPalabrasinAction()
    {
        //extension methods
        return librosCollection.Where(p =>p.PageCount>250 && p.Title.Contains("in Action") );

        //query expresions
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in action") select l;
    }
    //all y any devuelven un booleano; sirven para hacer comprobaciones en la colección
    // all: debe cumplir la condicion para todos los elementos
    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p=>p.Status!=string.Empty);
    }
    // any: si almenos uno cumple con la condición
    public bool SiAlgunLibroFuePublicado2005()
    {
        return librosCollection.Any(p=>p.PublishedDate.Year==2005);
    }
    //contains: si existe o no un elemento especifico en la coleccion
    //Where si cumple la condición retorna los valores 
    public IEnumerable <Book> LibrosdePython()
    {
        return librosCollection.Where(p=>p.Categories.Contains("Python"));
    }
    //Ordenar: Operador OrderBy y OrderbyDescending
    //OrderBy
    public IEnumerable <Book> LibrosdeJavaPorNombreAscendente()
    {
        return librosCollection.Where(p=>p.Categories.Contains("Java")).OrderBy(p=> p.Title);
    }
    //OrderByDescending
    public IEnumerable <Book> LibrosDeMasDe450PagOrdenadosPorNumPagDes()
    {
        return librosCollection.Where(p=>p.PageCount>450).OrderByDescending(p=> p.PageCount);
    }
    //Operador Take and Skip
    //Tak: cantidad de elementos a tomar
    //Skip: omitir cierta cantidad de registro y seleccionar el resto
    //Take
    public IEnumerable <Book> TresPrimerosLibrosOrdenadosPorFecha()
    {
        return librosCollection.Where(p=>p.Categories
        .Contains("Java"))
        .OrderByDescending(p=> p.PublishedDate)
        .Take(3);
    }
    //Skip
    public IEnumerable <Book> TerceryCuartoLibroDeMas400Pag()
    {
        return librosCollection
        .Where(p=>p.PageCount>400)
        .Take(4)
        .Skip(2);
    }
    //Select: filtrar columnas
    public IEnumerable <Book> TresPrimerosLibrosDeLaColeccion()
    {
        return librosCollection.Take(3)
        .Select(p=>new Book () {Title=p.Title, PageCount= p.PageCount});
    }
//operadores de agregacion; permite realizar calculo sobre toda la operacion y devolver un dato en especifico
//LongCount soporta 64 bits y Count: soporta 32 bits (realizan la cuenta de elementos) 
    public long CantidadDeLibrosEntre200y500Pag()
    {
        //return librosCollection.Where(p=>p.PageCount>=200 && p.PageCount<=500).LongCount();
        return librosCollection.LongCount(p=>p.PageCount>=200 && p.PageCount<=500);
    }
    //operador min y max: valores máximos y mínimos
    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p=>p.PublishedDate);
    }
    public int NumeroDePagLibroMayor()
    {
        return librosCollection.Max(p=>p.PageCount);
    }
    //operador minby y maxby para hallar valores del objeto completo
    public Book LibroConMenorNumeroDePaginas()
    {
        return librosCollection.Where(p=>p.PageCount>0).MinBy(p=>p.PageCount);
    }
    public Book LibroConFechaPublicacionMasReciente()
    {
        return librosCollection.MaxBy(p=>p.PublishedDate);
    }
    //operador summ y agregate
    //sum suma los registros
    public int SumaDeTodasLasPaginasLibrosEntre200y500()
    {
        return librosCollection.Where(p=>p.PageCount>=0 && p.PageCount<=500).Sum(p=>p.PageCount);
    }

    //agregate
    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return librosCollection
        .Where(p=>p.PublishedDate.Year>2015)
        .Aggregate("",(TitulosLibros, next)=>
        {
        if(TitulosLibros !=string.Empty)
        
            TitulosLibros+="-"+next.Title;
        else
            TitulosLibros+=next.Title;
            
        return TitulosLibros;
        } );
    }
}