#language: pt

Funcionalidade: Cadastro de usuario
	EU COMO usuário do sistema
	DESEJO realizar o cadastro de novos usuários
	PARA QUE seja possível armazenar e gerenciar seus dados

@usuario
Esquema do Cenario: Cadastrar um usuário
	Dado que eu esteja na tela de cadastro de usuário
	E insira meus <nomes> nomes
	E insira meu <email>
	E insira uma senha com <senha> caracter
	Quando clicar em no botão Cadastrar
	Então a página <exibe> meu cadastro feito em uma tabela

Exemplos: 
	| nomes                      | email                                | senha            | exibe |
	| Nome Sobrenome             | teste@teste.com                      | 12345678         | sim   |
	| Nome                       | teste@teste.com                      | 12345678         | não   |
	| Nome Sobrenome             | teste@teste.co1                      | 12345678         | não   |
	| Nome Sobrenome             | teste@teste.com                      | 1234567          | não   |
	| Nome Sobrenome1 Sobrenome2 | nome.sobrenome1.sobrenome2@teste.com | !@#$%¨&*()ewq=-+ | sim   |