## BBNetCore

Biblioteca de acesso às apis do Banco do Brasil(BB), baseada em .Net Standard 2.0.

### Primeiros passos

- Criar conta no portal [Developer BB](https://app.developers.bb.com.br/) com cpf do administrador da conta.
- V2 obriga a criação de certificado digital para testes e produção.
- Criar 2 projetos, um para Teste e um para Prod, um vez que o projeto seja aprovado para produção, não funciona em
  homolog.

As implementações da biblioteca atendem a versão 2 da API. 

### API's implementadas?

- **Boletos**; criar, criar com PIX, consultar e cancelar.
- **PIX de Boletos**; criar, consultar e cancelar. Para gerar PIX de boleto é necessário que o boleto já tenha sido registrado, via API ou troca de arquivo.
- **PIX**; criar, consultar e devolução.

### Como usar?
Exemplo basico de uso para geração de PIX.
```csharp    
    //Configurações iniciais do serviço.
    var options = new Configuracao
    {   
        //A versão 2 da API obriga o yso de certificado digital, nas requisições
        Certificado = new X509Certificate2("arquivocertificado"),    
        AmbienteApi = AmbienteApi.Producao,
        ChaveApp = "...",
        ClienteId = "...",
        ClienteSecret = "..." 
    };
    
    //Client contendo os serviços da API de PIX.
    var client = new Pix(VersaoApi.V2, options);
    
    //Dados da cobrança
    var dados = new DadosPix()
    {
        Calendar = new DadosCalendario(3600),
        Valores = new DadosValores(10.15M),
        ChavePix = "9e881f18-cc66-4fc7-8f2c-a795dbb2bfc1",
        Devedor = new DadosDevedor
        {
            Cnpj = "12345678000195",
            Nome = "Empresa de Serviços SA"
        },
        DecricaoCobranca = "Serviço prestado"
    };
    
    //Cria uma cobrança de pix
    var cobranca = await _pix.GerarAsync(dados);    
    Console.WriteLine($"Cobrança registrada. TransacaoId: {retorno.TransacaoId} PixCopiaCola: {retorno.PixCopiaCola}");
    
    //Consulta a cobrança pelo id de transação, para conferir os dados registrados
    var consulta = await _pix.ConsultarAsync("QEBTWpwGL2yT7ul3AVWdKCZ8hF");
    Console.WriteLine($"Cobrança encontrada. TransacaoId: {consulta.TransacaoId}");    
```
OBS: Para mais exemplos consulte o projeto de testes unitários.

### Exemplos
Você pode executar os exemplos contidos no projeto **PixBB.Test**

### Contributing
Relatórios de bugs e solicitações pull são bem-vindos no GitHub em https://github.com/luisjurassic/bbnetcore.

### Licença
A biblioteca está disponível como código aberto sob os termos da [Licença MIT](LICENSE).