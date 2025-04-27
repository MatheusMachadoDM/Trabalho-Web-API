import React, { useState, useEffect } from 'react';
import './ListaReservas.css'; // Importando o CSS

interface Hospede {
  hospedeId: number;
  nome: string;
  cpf: string;
  email: string;
  telefone: string;
}

interface Reserva {
  reservaId: number;
  checkIn: string;
  checkOut: string;
  hospedeId: number;
  hospede: Hospede;
}

const ListaReservas: React.FC = () => {
  const [reservas, setReservas] = useState<Reserva[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [selectedReserva, setSelectedReserva] = useState<Reserva | null>(null);
  const [message, setMessage] = useState('');

  useEffect(() => {
    const fetchReservas = async () => {
      try {
        const response = await fetch('http://localhost:5257/HotelAPI/reserva');
        if (!response.ok) {
          throw new Error(`Erro ao buscar reservas: ${response.status}`);
        }
        const data = await response.json();
        setReservas(data);
      } catch (error: any) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchReservas();
  }, []);

  const handleDelete = async (reservaId: number) => {
    const confirmDelete = window.confirm('Tem certeza que deseja excluir esta reserva?');

    if (!confirmDelete) {
      return;
    }

    try {
      const response = await fetch(`http://localhost:5257/HotelAPI/reserva${reservaId}`, {
        method: 'DELETE',
      });

      if (!response.ok) {
        throw new Error('Erro ao excluir reserva');
      }

      setMessage('Reserva excluída com sucesso!');
      setReservas(reservas.filter((reserva) => reserva.reservaId !== reservaId));
    } catch (error: any) {
      setMessage(`Erro: ${error.message}`);
    }
  };

  const handleEditClick = (reserva: Reserva) => {
    setSelectedReserva(reserva);
  };

  const handleUpdateReserva = async (updatedReserva: Reserva) => {
    try {
      const response = await fetch(`http://localhost:5257/HotelAPI/reserva${updatedReserva.reservaId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedReserva),
      });

      if (!response.ok) {
        throw new Error('Erro ao atualizar reserva');
      }

      const data = await response.json();
      setMessage('Reserva atualizada com sucesso!');
      setReservas((prevState) =>
        prevState.map((reserva) =>
          reserva.reservaId === updatedReserva.reservaId ? updatedReserva : reserva
        )
      );
      setSelectedReserva(null);
    } catch (error: any) {
      setMessage(`Erro: ${error.message}`);
    }
  };

  const handleCancelUpdate = () => {
    setSelectedReserva(null);
  };

  if (loading) {
    return <p>Carregando reservas...</p>;
  }

  if (error) {
    return <p className="error">Erro ao carregar reservas: {error}</p>;
  }

  return (
    <div>
      <h2>Lista de Reservas</h2>
      {message && <p className="message">{message}</p>}
      {reservas.length === 0 ? (
        <p>Nenhuma reserva encontrada.</p>
      ) : (
        <ul>
          {reservas.map((reserva) => (
            <li key={reserva.reservaId}>
              ID: {reserva.reservaId} | Check-in: {reserva.checkIn} | Check-out: {reserva.checkOut} |
              Hóspede: {reserva.hospede.nome} (CPF: {reserva.hospede.cpf}) 
              <button className="update" onClick={() => handleEditClick(reserva)}>Editar</button>
              <button className="cancel" onClick={() => handleDelete(reserva.reservaId)}>Excluir</button>
            </li>
          ))}
        </ul>
      )}

      {selectedReserva && (
        <div>
          <h3>Editar Reserva</h3>
          <form
            onSubmit={(e) => {
              e.preventDefault();
              handleUpdateReserva(selectedReserva);
            }}
          >
            <div>
              <label>Check-in:</label>
              <input
                type="date"
                value={selectedReserva.checkIn}
                onChange={(e) => setSelectedReserva({ ...selectedReserva, checkIn: e.target.value })}
                required
              />
            </div>
            <div>
              <label>Check-out:</label>
              <input
                type="date"
                value={selectedReserva.checkOut}
                onChange={(e) => setSelectedReserva({ ...selectedReserva, checkOut: e.target.value })}
                required
              />
            </div>
            <div>
              <label>Nome do Hóspede:</label>
              <input
                type="text"
                value={selectedReserva.hospede.nome}
                onChange={(e) =>
                  setSelectedReserva({
                    ...selectedReserva,
                    hospede: { ...selectedReserva.hospede, nome: e.target.value },
                  })
                }
                required
              />
            </div>
            <div>
              <label>Email:</label>
              <input
                type="email"
                value={selectedReserva.hospede.email}
                onChange={(e) =>
                  setSelectedReserva({
                    ...selectedReserva,
                    hospede: { ...selectedReserva.hospede, email: e.target.value },
                  })
                }
                required
              />
            </div>
            <div>
              <label>Telefone:</label>
              <input
                type="text"
                value={selectedReserva.hospede.telefone}
                onChange={(e) =>
                  setSelectedReserva({
                    ...selectedReserva,
                    hospede: { ...selectedReserva.hospede, telefone: e.target.value },
                  })
                }
              />
            </div>
            <button type="submit">Atualizar Reserva</button>
            <button className="cancel" type="button" onClick={handleCancelUpdate}>
              Cancelar
            </button>
          </form>
        </div>
      )}
    </div>
  );
};

export default ListaReservas;
