import React from 'react';
import axios from 'axios';
import { Form, Col, Row, Button } from 'react-bootstrap';
import DatePicker from 'react-date-picker'

class GetTaxForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            municipalities: [],
            selectedMunicipality: null,
            taxDate: new Date(),
            btnGetTaxDisabled: false,
            taxOutput: 0
        };
    }
    componentDidMount() {
        if (this.state.municipalities.length > 0) {
            const selectedMunicipality = this.state.municipalities[0];
            this.setState({ selectedMunicipality });
        }   
        
        axios.get('https://localhost:44380/api/Taxes/MunicipalitiesNames').then(response => {
            console.log(response.data);
            const municipalities = response.data;
            this.setState({ municipalities });
        })
    }
    render() {
        return (
            <Form>
                <Form.Group as={ Row }>
                    <Col>
                        <Form.Control as="select" className="float-right" id="municipalities" onChange={ this.onMunicipalitiesSelect.bind(this) }>
                            {
                                this.state.municipalities.map((option, index) => {
                                    return (<option key={ index } value={ option }>{ option }</option>);
                                })
                            }
                        </Form.Control>
                    </Col>
                    <Col className="d-flex flex-column">
                        <DatePicker 
                            className="h-100"
                            value={ this.state.taxDate }
                            onChange={ (e) => this.onTaxDatePick(e) }
                            name="TaxDate"
                            dateFormat="MM/dd/yyyy"
                        />
                    </Col>
                    <Col className="d-flex flex-column">
                        <Button className="h-100" id="btnGetTax" variant="info" type="button"
                            onClick={ () => this.onGetTax() }
                            disabled={ this.state.btnGetTaxDisabled }>Get Tax
                        </Button>
                    </Col>`
                </Form.Group>
                <Form.Group className="border border-primary"as={ Row }>
                    <Col>
                        <label className="float-right m-0">{ this.state.taxOutput }</label>
                    </Col>                   
                </Form.Group>
            </Form>
        );
    }
    onMunicipalitiesSelect(e) {
        const selectedMunicipality = e.target.value;
        this.setState({ selectedMunicipality });
    }
    onTaxDatePick(e) {
        const taxDate = e;
        this.setState({ taxDate });
    }
    onGetTax() {
        this.setState({ btnGetTaxDisabled: true });

        axios.get('https://localhost:44380/api/Taxes', {
            params: {
                municipalityName: this.state.selectedMunicipality,
                taxDate: this.state.taxDate
            }
        }).then(response => {
            const taxOutput = response.data;
            this.setState({ taxOutput });
        })

        this.setState({ btnGetTaxDisabled: false });
    }
}
export default GetTaxForm;