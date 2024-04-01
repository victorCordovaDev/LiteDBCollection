using System.Linq;
using LiteDB;
using K4os.Compression.LZ4;
using System.Text;

public class LiteDbExample
{
  private readonly string _fileName = "PruebaDB.dblite";

  public void Run()
  {
    using (var db = new LiteDatabase(_fileName))
     {
                // Obtener la colección "customer"
                var col = db.GetCollection("customer");

                // Loop para insertar 100,000 datos
                for (int i = 1; i < 100001; i++)
                {
                    // Insertar documento en la colección
                    col.Insert(new BsonDocument { ["_id"] = i + 1, ["Name"] = $"Person {i + 1}" });
                }

                // Crear un índice en el campo "Name" si aún no existe
                col.EnsureIndex("Name");
      }
            Console.WriteLine("Datos insertados exitosamente.");
  }
    
  public static void Main(string[] args)
  {
    new LiteDbExample().Run();
  }
}