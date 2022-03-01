import React, { useState, useEffect } from 'react';
import CreditCardProvider from './CreditCardProvider';
import { Link } from 'react-router-dom';

const ProviderList = () => {
    const [loading, setLoading] = useState(true);
    const [data, setData] = useState({});

    useEffect(() => {
        fetch('/api/providers/all')
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
            <h1>Credit Card Providers</h1>
            {loading ?
                (<p><em>Loading...</em></p>)
                : (data && data.length && data.map((provider, index) =>

                        <CreditCardProvider provider={provider} key={index} />
                    )
                )}

            <div className='button-container'>
                <Link className="add-button" to={`/providers/add/`}>Add New Provider</Link>
            </div>
        </div>
    );
}

export default ProviderList;