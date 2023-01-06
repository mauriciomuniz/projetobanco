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
        public Usuario RegistrarNovoUsuario(long cpf, string titular, string senha, double saldo ) 
        {
		    return cc.RegistrarNovoUsuario(cpf, titular, senha, saldo);
	    }

        public void DeletarUsuario(long buscacpf)
        {
            this.cc.DeletarUsuario(buscacpf);
        }

        public void ListarTodasAsContas()
        {
            this.cc.ListarTodasAsContas();
        }

        public void DetalhesUsuario(long buscacpf2)
        {
            this.cc.DetalhesUsuario(buscacpf2);
        }

        public void TotalBanco()
        {
            this.cc.TotalBanco();
        }

        public Usuario ValidacaoConta()
        {
            return cc.ValidacaoConta();
        }

        public void Sacando(Usuario logado)
        {
            this.cc.Sacando(logado);
        }

        public void Depositando(Usuario logado)
        {
            this.cc.Depositando(logado);
        }

        public void Transferindo(Usuario logado, Usuario contadestino, double valorTransferir)
        {
            this.cc.Transferindo(logado, contadestino, valorTransferir);
        }

        public long CPFigual(long cpf)
        {
            return cc.CPFigual(cpf);
        }

        public long CPFvalido(String cpf)
        {
            return cc.CPFvalido(cpf);
        }

        public Usuario DestinoValido()
        {
            return cc.DestinoValido();
        }

    }
}