import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './TelaHistoricoCursos.jsx'
import TelaListaPresença from './TelaListaPresença.jsx'
import TelaCursoAndamento from './TelaCursoAndamento.jsx'
import TelaHistoricoCursos from './TelaHistoricoCursos.jsx'
import TelaCursos from './TelaCursos.jsx'
import TelaInscriçãoCurso from './TeleInscriçãoCurso.jsx'
import AdicionarCurso from './AdicionarCurso.jsx'
import TelaInicial from './TelaInicial.jsx'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'

const router = createBrowserRouter([
  {
    path:"/",
    element: <TelaInicial/>
  },
  {
    path:"TelaCursoAndamento",
    element:<TelaCursoAndamento/>
  },
  {
    path:"AdicionarCurso",
    element:<AdicionarCurso/>
  },
  {
   path:"TelaListaPresença",
   element:<TelaListaPresença/>
  },
  {
    path:"TelaInscriçãoCurso",
    element:<TelaInscriçãoCurso/>
  },
  {
    path:"TelaHistoricoCursos",
    element:<TelaHistoricoCursos/>
  },
  {
    path:"TelaCursos",
    element:<TelaCursos/>
  },
])

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <RouterProvider router={router}/>
  </StrictMode>,
)
