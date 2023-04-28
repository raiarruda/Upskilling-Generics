using ContratoPersistencia;
using System.Security.Principal;
using System.Text.Json;

namespace JsonPersistencia;

public class PersistenciaJson : IPersistencia

{

    static readonly string rootDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    static readonly string dataDirectory = Path.Combine(rootDirectory, "data");

    public PersistenciaJson(string _nomeArquivo)
    {
        this.nomeArquivo = _nomeArquivo;
    }

    private string nomeArquivo;

    public void Salvar(IEntidade entidade)
    {
        var entidades = this.Lista(entidade.GetType());
        entidades.Add(entidade);

        string stringJson = JsonSerializer.Serialize(entidades);
        string caminhoArquivo = dataDirectory + "/" + nomeArquivo;
        Directory.CreateDirectory(dataDirectory);
        File.WriteAllText(caminhoArquivo, stringJson);
    }

    public void Atualizar(IEntidade entidade)
    {
        var entidades = this.Lista(entidade.GetType());

        var objLocalizado = entidades.Find(e => e.Id == entidade.Id);
        if (objLocalizado == null)
        {
            new Exception($"Entidade({entidade.GetType().Name}) não localizada");
            return;
        }

        foreach (var piLocalizado in objLocalizado.GetType().GetProperties())
        {
            var piEntidadePassada = entidade.GetType().GetProperty(piLocalizado.Name);
            if (piEntidadePassada != null)
            {
                piLocalizado.SetValue(objLocalizado, piEntidadePassada.GetValue(entidade));
            }
        }

        string stringJson = JsonSerializer.Serialize(entidades);
        string caminhoArquivo = dataDirectory + "/" + nomeArquivo;
        File.WriteAllText(caminhoArquivo, stringJson);
    }

    public List<IEntidade> Lista(Type tipoEntidade)
    {
        string caminhoArquivo = dataDirectory + "/" + nomeArquivo;
        if (!File.Exists(caminhoArquivo)) return new List<IEntidade>();
        string stringJson = File.ReadAllText(caminhoArquivo);

        Type tipoLista = typeof(List<>).MakeGenericType(tipoEntidade);
        object? lista = JsonSerializer.Deserialize(stringJson, tipoLista);
        if (lista == null) return new List<IEntidade>();

        List<IEntidade> entidades = (List<IEntidade>)lista;
        return entidades;
    }

    public void Apagar(IEntidade entidade)
    {
        var entidades = this.Lista(entidade.GetType());
        entidades.RemoveAll(e => e.Id == entidade.Id);

        string stringJson = JsonSerializer.Serialize(entidades);
        string caminhoArquivo = dataDirectory + "/" + nomeArquivo;
        File.WriteAllText(caminhoArquivo, stringJson);
    }
}