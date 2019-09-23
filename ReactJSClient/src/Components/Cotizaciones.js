import React, { Component } from "react";
import Navigation from './Navigation'
import ExchangeForm from "./ExchangeForm";
import axios from 'axios';

class Cotizaciones extends Component{
    constructor(){
        super();
        this.state = {
            titulo: "Aplicacion de Cotizaciones",
            tiposCambio : []
        }

        this.handleFindExchange = this.handleFindExchange.bind(this);
    }

    //WARNING! To be deprecated in React v17. Use componentDidMount instead.
    componentDidMount() {
        const callApi = () => {
            axios.get('http://localhost:51168/api/Cotizacion')
            .then(res => {
            const tiposCambio = res.data;
            this.setState({ tiposCambio });
            })
        };

        callApi();
        
        // llama a la funcion cada 5 segundos
        const interval = setInterval(() => {
            callApi();
          }, 5000);
          return () => clearInterval(interval);
    }

    handleFindExchange(cambio){
        // filtra por la moneda seleccionada en el combo
        this.setState({
            tiposCambio : this.state.tiposCambio.filter((tc) => {
                return tc.moneda === cambio.moneda;
            })
        });
    }

    removeExchange(index) {
        this.setState({
          tiposCambio: this.state.tiposCambio.filter((e, i) => {
            return i !== index
          })
        });
      }

    render(){ 
        /*recorre tiposCambio las cotizaciones de la api con map y dibuja el rectangulo */
        console.log(this.state.tiposCambio.length)
        const tiposCambio = this.state.tiposCambio.map((cambio, i) => {
            return(
                <div className="col-md-4" key={i}>
                    <div className="card mt-4">
                        <div className="card-title text-center">
                            <h3>{cambio.moneda}</h3>
                            <span className="badge">
                                {cambio.precio}
                            </span>
                        </div>
                        <div className="card-footer center">
                            <button
                                className="btn btn-danger"
                                onClick={this.removeExchange.bind(this, i)}>
                                Delete
                            </button>
                        </div>
                    </div>
              </div>
            )
        }
        )
        if (this.state.tiposCambio.length > 0) {
        return(
            <div>
                <Navigation titulo={this.state.titulo} length={this.state.tiposCambio.length}/>
                <div className="container" >
                    <div className="row mt-4">
                        <div className="col-md-4 text-center">
                            <ExchangeForm onFindExchange={this.handleFindExchange} />
                        </div>
                        <div className="col-md-8">
                            <div className="row">
                            
                                 {
                                    tiposCambio  
                                    }
                            </div>
                        </div>
                    </div>
                </div>
           </div>
        ) }
        return <p className="text-center">Cargando cotizaciones...</p>;
    }
}

export default Cotizaciones;