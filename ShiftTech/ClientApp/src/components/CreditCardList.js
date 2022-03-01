import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import CreditCard from './CreditCard';

const CreditCardList = () => {
    const [loading, setLoading] = useState(true);
    const [data, setData] = useState({});

    useEffect(() => {
        fetch('/api/cards/all')
            .then(response => response.json())
            .then(responseData => {
                setLoading(false);
                setData(responseData);
            })
            .catch(ex => {
                setLoading(false);
            });
    }, []);

    return (
        <div>
            <h1>Credit Cards</h1>
            {loading ?
                (<p><em>Loading...</em></p>)
                : (data && data.length && data.map((card, index) =>

                        <CreditCard card={card} key={index} />
                    )
                )}

            <div className='button-container'>
                <Link className="add-button" to={`/cards/add/`}>Add New Credit Card</Link>
            </div>
        </div>
    );
}

export default CreditCardList;