import React, { Component } from 'react';
import { Modal, Button } from 'react-bootstrap';

export class ResourceList extends Component {
    static displayName = ResourceList.name;

    constructor(props) {
        super(props);
        this.state = {
            resources: [],
            loading: true,
            showBookingModal: false,
            selectedResource: null,
            dateFrom: '',
            dateTo: '',
            quantity: ''
        };
    }

    componentDidMount() {
        this.populateResourceData();
    }

    static renderResourcesTable(resources, onClickBook) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Quantity</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {resources.map(resource =>
                        <tr key={resource.id}>
                            <td>{resource.id}</td>
                            <td>{resource.name}</td>
                            <td>{resource.quantity}</td>
                            <td>
                                <Button onClick={() => onClickBook(resource)}>Book Here</Button>
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }


    onClickBook = (resource) => {
        this.setState({ selectedResource: resource, showBookingModal: true });
    }

    hideBookingModal = () => {
        this.setState({ showBookingModal: false });
    }

    handleInputChange = (event) => {
        const target = event.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    submitBooking = async (event) => {
        event.preventDefault();
        const bookingData = {
            command: "BookResource",
            dateFrom: this.state.dateFrom,
            dateTo: this.state.dateTo,
            bookedQuantity: parseInt(this.state.quantity),
            resourceId: this.state.selectedResource.id
        };
        try {
            const response = await fetch('booking', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(bookingData)
            });
            if (!response.ok) {
                throw new Error('Failed to create booking!');
            }
            this.setState({ bookingCreated: true });
            setTimeout(() => {
                this.setState({ showBookingModal: false, bookingCreated: false });
                this.populateResourceData();
            }, 3000);
        } catch (error) {
            console.error(error);
        }
    }







    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : ResourceList.renderResourcesTable(this.state.resources, this.onClickBook, this.showBookingModal);

        return (
            <div>
                <h1 id="tabelLabel" >Resources</h1>
                <p>Here you can create your Booking</p>
                {contents}
                {this.renderBookingModal()}
            </div>
        );
    }

    renderBookingModal() {
        const { showBookingModal, selectedResource, dateFrom, dateTo, quantity, bookingCreated } = this.state;

        return (
            <Modal show={showBookingModal} onHide={this.hideBookingModal}>
                <Modal.Header closeButton>
                    <Modal.Title>Create Booking for {selectedResource && selectedResource.name}</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    {selectedResource && (
                        <form onSubmit={this.submitBooking}>
                            <div className="form-group">
                                <label>Date From:</label>
                                <input
                                    type="date"
                                    className="form-control"
                                    name="dateFrom"
                                    value={dateFrom}
                                    onChange={this.handleInputChange}
                                    required
                                />
                            </div>
                            <div className="form-group">
                                <label>Date To:</label>
                                <input
                                    type="date"
                                    className="form-control"
                                    name="dateTo"
                                    value={dateTo}
                                    onChange={this.handleInputChange}
                                    required
                                />
                            </div>
                            <div className="form-group">
                                <label>Quantity:</label>
                                <input
                                    type="number"
                                    className="form-control"
                                    name="quantity"
                                    min="1"
                                    max={selectedResource.quantity}
                                    value={quantity}
                                    onChange={this.handleInputChange}
                                    required
                                />
                            </div>
                            <div className="form-group">
                                <Button type="submit" variant="primary">
                                    Book
                                </Button>
                            </div>
                        </form>
                    )}
                </Modal.Body>
                <Modal.Footer>
                    {bookingCreated && (
                        <div className="alert alert-success" role="alert">
                            Successful booking
                        </div>
                    )}
                </Modal.Footer>
            </Modal>
        );
    }




    async populateResourceData() {
        const response = await fetch('resource');
        const data = await response.json();
        this.setState({ resources: data, loading: false });
    }
}
