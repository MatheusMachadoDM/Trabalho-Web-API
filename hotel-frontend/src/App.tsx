//Importando biblioteca
import React from 'react'; 
//Importando componentes
import FormularioReserva from './components/FormularioReserva';
import ListaReservas from './components/ListaReservas';
import './App.css'; 

//Função principal 
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
