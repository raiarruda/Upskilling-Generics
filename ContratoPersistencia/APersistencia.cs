namespace ContratoPersistencia;
public abstract class APersistencia
{
    public abstract void Incluir(IEntidade entidade);
    public abstract void Atualizar(IEntidade entidade);
    public abstract List<IEntidade> Buscar(Type tipoEntidade);
    public abstract void Apagar(IEntidade entidade);

    public string QuemEVoce()
    {
        return "Eu sou uma abstração e tenho mais poderes do que a interface";
    }
}
