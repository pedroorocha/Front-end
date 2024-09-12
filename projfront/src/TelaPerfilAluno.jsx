import HeaderMenu from "./HeaderMenu"
import './TelaPerfilAluno.css'
function TelaPerfilAluno(){
    return(
    <body>
        <HeaderMenu/>
        <h2>Cursos Em Destaque: </h2>
        <div id="curso">
            <button id="inscrevase">Inscreva-se</button>
            <h3>Aberto | Titulo do curso
            <p>Data</p>
            <div id="data"></div>
            </h3>
        </div>
        <div id="curso2">
        <button id="inscrevase2">Inscreva-se</button>
        <h3>Aberto | Titulo do curso
        <p>Data</p>
        <div id="data"></div>
        </h3>
        </div>
        <button id="vermais"><trong>Ver Mais</trong></button>
        <div id="linhaT"></div>
        <div id="textos">
            <p id="textinhos">Atividades acadêmicas de complementação da
            formação específica e ou campo profissional</p>
            <p id="textinhos">Atividades acadêmicas de ensino</p>
            <p id="textinhos">Atividades acadêmicas de pesquisa e
            produção científica</p>
            <p id="textinhos">Atividades acadêmicas gerais</p>
            <p id="textinhos">Atividades acadêmicas de extensão</p>
            <p id="textinhos">Atividades acadêmicas esportivas e culturais</p>
            <p id="textinhos">Atividades acadêmicas de complementação da
            formação específica e ou campo profissional</p>
        </div>
    </body>
    )

}
export default TelaPerfilAluno