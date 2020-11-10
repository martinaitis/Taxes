import React from 'react';
import { Row, Col } from 'react-bootstrap';

class Header extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <Row id='header'>
                <Col>
                    <div class="jumbotron">
                        <h1 className="my-0">{this.props.headerTitle}</h1>
                    </div>
                </Col>
            </Row>
        );
    }
}

export default Header;