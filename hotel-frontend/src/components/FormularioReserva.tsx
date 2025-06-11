import React, { useState } from 'react';

interface Hospede {
  hospedeId: number;
  nome: string;
  cpf: string;
  email: string;
  telefone: string;
}

interface Reserva {
  checkIn: string;
  checkOut: string;
  hospede: Hospede;
}

//Define um componente funcional
const FormularioReserva: React.FC = () => {
  //Cada useState armazena o valor de um campo do form
  const [nome, setNome] = useState('');
  const [cpf, setCpf] = useState('');
  const [email, setEmail] = useState('');
  const [telefone, setTelefone] = useState('');
  const [checkIn, setCheckIn] = useState('');
  const [checkOut, setCheckOut] = useState('');
  const [message, setMessage] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();//Evita o recarregamento da página

    // Criar um objeto com os dados do hospede
    const hospede: Hospede = {
      hospedeId: 0, // Se for um novo, o ID será gerado pela API
      nome,
      cpf,
      email,
      telefone,
    };
    
    const reserva: Reserva = {
      checkIn,
      checkOut,
      hospede,
    };
    
    //Envia dados para a API
    try {
      const response = await fetch('http://localhost:5257/HotelAPI/reserva', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(reserva),
      });

      //Verifica se houve erro
      if (!response.ok) {
        throw new Error('Erro ao criar a reserva');
      }

      //Caso não tenha erro, limpa o form
      const data = await response.json();
      setMessage('Reserva criada com sucesso!');
      
      setNome('');
      setCpf('');
      setEmail('');
      setTelefone('');
      setCheckIn('');
      setCheckOut('');
    } catch (error: any) {
      setMessage(`Erro: ${error.message}`);
    }
  };
  
  return (
    <div>
      <h2>Criar Reserva</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Nome:</label>
          //Atualiza o estado quando o usuario digita
          <input type="text" value={nome} onChange={(e) => setNome(e.target.value)} required />
        </div>
        <div>
          <label>CPF:</label>
          <input type="text" value={cpf} onChange={(e) => setCpf(e.target.value)} required />
        </div>
        <div>
          <label>Email:</label>
          <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} required />
        </div>
        <div>
          <label>Telefone:</label>
          <input type="text" value={telefone} onChange={(e) => setTelefone(e.target.value)} required />
        </div>
        <div>
          <label>Check-in:</label>
          <input type="date" value={checkIn} onChange={(e) => setCheckIn(e.target.value)} required />
        </div>
        <div>
          <label>Check-out:</label>
          <input type="date" value={checkOut} onChange={(e) => setCheckOut(e.target.value)} required />
        </div>
        <button type="submit">Criar Reserva</button>
      </form>
      {message && <p>{message}</p>}
    </div>
  );
};

export default FormularioReserva;
