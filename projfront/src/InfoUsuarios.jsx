import HeaderMenu from './HeaderMenu'
import './infoUsuarios.css'
import { useLocation } from "react-router-dom";
import { useState, useEffect } from 'react';
import axios from 'axios';

function InfoUsuarios(props){
    
    const location = useLocation();
    const { matricula } = location.state || {};
    const [listaAlunos, setListaAlunos] = useState("")
    const [listaCursos, setListaCursos] = useState([ ])

    useEffect(() =>{
        const fetchAlunos = async () => {
            try {
                const response = await axios.get(`http://localhost:5077/api/aluno/${matricula}`);
                setListaAlunos(response.data);
                
            } catch (error) {
                console.error("Erro ao buscar eventos:", error);
                
            }
        };
        fetchAlunos();
    }, [])

    useEffect(() =>{
        const fetchCursos = async () => {
            try {
                const response = await axios.get(`http://localhost:5077/api/evento/lista/${matricula}`);
                setListaCursos(response.data);
                
            } catch (error) {
                console.error("Erro ao buscar eventos:", error);
                
            }
        };
        fetchCursos();
    }, [])


    return(
        <div>
            <HeaderMenu/>
            <div>
                <label id='infor' ><strong>Nome:</strong> {listaAlunos.nome}</label>
                <br/>
                <label id='infor'><strong>E-mail:</strong> {listaAlunos.email}</label>
                <br/>
                <label id='infor'><strong>cpf:</strong> {listaAlunos.cpf}</label>
                <br/>
                <label id='infor'><strong>Curso:</strong> {listaAlunos.curso}</label>
                <br/>
                <label id='infor'><strong>Data de Nascimento:</strong> {listaAlunos.data}</label>
                <br/>
                <label id='infor'><strong>Telefone:</strong> {listaAlunos.telefone}</label>
                <br/>
                <label id='infor'><strong>Horas Complementares:</strong></label>
                <br/>
                <label id='infor'><i>Modalidade A: {listaAlunos.horasComplementaresA}H</i></label>
                <br/>
                <label id='infor'><i>Modalidade B: {listaAlunos.horasComplementaresB}H</i></label>
                <br/>
                <label id='infor'><i>Modalidade C: {listaAlunos.horasComplementaresC}H</i></label>
                <br/>
                <label id='infor'><i>Modalidade D: {listaAlunos.horasComplementaresD}H</i></label>
                <br/>
                <label id='infor'><i>Modalidade E: {listaAlunos.horasComplementaresE}H</i></label>
                <br/>
                <label id='infor'><i>Modalidade F: {listaAlunos.horasComplementaresF}H</i></label>
                <br/>
                <label id='infor'><strong>Cursos:</strong></label>

                <ul>
                    {listaCursos.map((evento) =>(
                            <p id='evento'>{evento.nome}</p>
                    ))}
                </ul>

            </div>
        </div>
        
    )

}
export default InfoUsuarios