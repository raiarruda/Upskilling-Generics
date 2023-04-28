namespace ContratoPersistencia;

public interface IPersistencia
{
    void Salvar(IEntidade entidade);
    void Atualizar(IEntidade entidade);
    List<IEntidade> Lista(Type tipoEntidade);
    void Apagar(IEntidade entidade);
}