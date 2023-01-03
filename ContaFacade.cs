namespace projetobanco
{

    public class ContaFacade
    {
        ControllerConta cc;
	
        public ContaFacade()
        {
            this.cc = new ControllerConta();
        }

        //chamadas
        public Usuario RegistrarNovoUsuario(int cpf, string titular, string senha, double saldo ) 
        {
		    return cc.RegistrarNovoUsuario(cpf, titular, senha, saldo);
	    }

        public void DeletarUsuario(int buscacpf)
        {
            this.cc.DeletarUsuario(buscacpf);
        }

        public void ListarTodasAsContas()
        {
            this.cc.ListarTodasAsContas();
        }

        public void DetalhesUsuario(int buscacpf2)
        {
            this.cc.DetalhesUsuario(buscacpf2);
        }

        public void TotalBanco()
        {
            this.cc.TotalBanco();
        }

    }
}