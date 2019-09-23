import React, { Component } from "react";

class ExchangeForm extends Component {
    constructor(){
        super();
        this.state = {
            moneda : '',
            precio: ''
        }
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    handleSubmit(e){
        // no refrescar la pantalla
        e.preventDefault();
        // paso el estado al metodo de la propiedad del evento, para que lo obtenga de la api
        this.props.onFindExchange(this.state);

        // una vez que lo manda resetea el form
        this.setState({
            moneda : '',
            precio: ''
        })
    }

    handleInputChange(e){
        const {value, name} = e.target;
        this.setState({
          [name]: value
        });
    }

    render(){
        return(
            <div className="card">
                <form onSubmit={this.handleSubmit} className="card-body">
                    
                    <div className="form-group">
                        <select
                            name="moneda"
                            className="form-control"
                            value={this.state.moneda}
                            onChange={this.handleInputChange}
                        >
                        <option>dolar</option>
                        <option>euro</option>
                        <option>real</option>
                        </select>
                    </div>
                    <button type="submit" className="btn btn-primary">
                        Buscar
                    </button>
                </form>
            </div>
        );
    }
}

export default ExchangeForm;