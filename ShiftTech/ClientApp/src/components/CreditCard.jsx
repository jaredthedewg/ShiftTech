import React from 'react';
import '../style/credit-card-provider.scss'

function CreditCard(props) {
    const { card } = props;
    const navigate = useNavigate();
    const deleteCard = (event) =>{
        const id = event.target.value;

        fetch('/api/cards/delete', {
            method: 'post',
            body: JSON.stringify(id),
            headers: {
              'Content-Type': 'application/json'
              }
          }).then((response) => {
            this.props.history.push("/cards/view");

          })

    }
    return (
        <div className="credit-card">
            <div className="credit-card-__number">{card.card_number}</div>
            <button className="delete-button" onClick={deleteCard} value={card.id}>Delete Credit Card</button>
        </div>
    );
}

export default CreditCard;
