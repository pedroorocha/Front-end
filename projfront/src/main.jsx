import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './TelaCursos.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <App />
  </StrictMode>,
)
