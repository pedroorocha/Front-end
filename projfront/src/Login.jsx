import Header from './header.jsx'
import './Login.css'
function Login(){

    return(
        
        <body>
            
            <div>
                <h1><strong>BEM-VINDO!</strong></h1>
                <br></br>
                <p id="email">E-mail: </p>
                <input id="imp_email" type="text" />
                <hr id="line1"/>
                <p id="senha">Senha: </p>
                <input id="imp_senha" type="password" />
                <hr id="line2"/>
                <a id='esq' href='exemplo.com'>Esqueceu sua senha?</a>
                <br></br>
                <button id='entra' type='button'>Entrar</button>
                <br></br>
                <button id='cadastra' type='button'>Cadastrar</button>
            </div>

        </body>
    )


} 
export default Login