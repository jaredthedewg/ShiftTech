import React from 'react';
import { useForm } from 'react-hook-form';

const CreditCardForm = () => {
  const { register, handleSubmit } = useForm();

  const onSubmit = (data) => {
    console.log('post data: ', JSON.stringify(data))
      fetch('/api/cards/create', {
        method: 'post',
        body: JSON.stringify(data),
        headers: {
          'Content-Type': 'application/json'
          }
      }).then((response) => {
        return response.json();
      })
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input defaultValue="card_number" {...register("card_number", { required: true })} />
      <input type="submit" />
    </form>
  );
};

export default CreditCardForm;