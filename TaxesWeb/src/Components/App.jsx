import React from 'react';
import { Container } from 'react-bootstrap';
import Header from './Header';
import GetTaxForm from './GetTaxForm';

class App extends React.Component {
    render() {
        return (
            <Container fluid className="w-75 p-3">
                <Header headerTitle={ "Very fancy header" } />
                <GetTaxForm />
            </Container>
        );
    }
}
export default App;