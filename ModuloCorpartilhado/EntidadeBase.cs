namespace consoleApp.ModuloCorpartilhado;

public abstract class EntidadeBase
{
    public int id { get; protected set; }

    public string nome { get; protected set; }

    protected EntidadeBase(string nome)
    {
        this.nome = nome;
    }

    public void SetId(int numero)
    {
        this.id = numero;
    }

    public int GetId()
    {
        return this.id;
    }

    public abstract void Editar(EntidadeBase entidade);

}