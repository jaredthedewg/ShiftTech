import React from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/Layout';
import Home from './components/Home';
import ProviderList from './components/ProviderList';
import ProviderForm from './components/ProviderForm';
import CreditCardForm from './components/CreditCardForm';
import CreditCardList from './components/CreditCardList';

function App () {
    return (
        <Layout>
            <Switch>
                <Route exact path='/' component={Home} />
                <Route path='/providers/view' component={ProviderList} /> 
                <Route path='/providers/add' component={ProviderForm} /> 
                <Route path='/cards/view' component={CreditCardList} /> 
                <Route path='/cards/add' component={CreditCardForm} /> 
            </Switch>
        </Layout>
    );
}

export default App;