import React from 'react';
import { useForm } from 'react-hook-form';

const ProviderForm = () => {
  const { register, handleSubmit } = useForm();

  const onSubmit = (data) => {
    console.log('post data: ', JSON.stringify(data))
      fetch('/api/providers/create', {
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
      <input defaultValue="name" {...register("name", { required: true })} />
      <input defaultValue="length" {...register("length", { required: true })} />
      <input defaultValue="regex" {...register("regex", { required: true })} />
      <input type="submit" />
    </form>
  );
};

export default ProviderForm;