import React from 'react';
import '../style/credit-card-provider.scss'

function CreditCardProvider(props) {
    const { provider } = props;
    const deleteProvider = (event) =>{
        const id = event.target.value;

        fetch('/api/providers/delete', {
            method: 'post',
            body: JSON.stringify(id),
            headers: {
              'Content-Type': 'application/json'
              }
          }).then((response) => {
            this.props.history.push("/providers/view");
          })

    }
    return (
        <div className="credit-card-provider">
            <div className="credit-card-provider__name">{provider.name}</div>
            <div className="credit-card-provider__regex">{provider.regex}</div>
            <div className="credit-card-provider__length">{provider.length}</div>
            <button className="delete-button" onClick={deleteProvider} value={provider.id}>Delete Provider</button>
        </div>
    );
}

export default CreditCardProvider;