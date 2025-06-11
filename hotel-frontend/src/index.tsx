import React from 'react';
//Importa o render do app
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';

//Conecta a div root com o react
const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

//Renderiza o app dentro do root
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
