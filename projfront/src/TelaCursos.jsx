import HeaderMenuVolta from "./HeaderMenuVoltar"
import Curso from "./Curso.jsx"
import './TelaCursos.css'
function TelaCursos(){

    return(
    <body>
        <HeaderMenuVolta/>
        <div>
        <input type="text" placeholder="Pesquisar" />
        <button id="pesquisa">lupa</button>
        <select id="dropdown">
            <option value="opcao1">Opção 1</option>
            <option value="opcao2">Opção 2</option>
            <option value="opcao3">Opção 3</option>
            <option value="opcao4">Opção 4</option>
        </select>
        <select id="dropdown2">
            <option value="opcao1">Opção 1</option>
            <option value="opcao2">Opção 2</option>
            <option value="opcao3">Opção 3</option>
            <option value="opcao4">Opção 4</option>
        </select>
        </div>
        
    </body>
    )
}
export default TelaCursos