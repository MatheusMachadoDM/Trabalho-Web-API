import React from 'react';
import FormularioReserva from './components/FormularioReserva';
import ListaReservas from './components/ListaReservas';
import './App.css'; // Você pode remover ou editar este arquivo de CSS

function App() {
  return (
    <div className="App">
      <h1>Sistema de Reservas</h1>
      <FormularioReserva />
      <hr />
      <ListaReservas />
    </div>
  );
}

export default App;