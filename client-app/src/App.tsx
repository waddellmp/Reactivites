import React from 'react';
import { Header, Icon, List } from 'semantic-ui-react';
import axios from 'axios';

class App extends React.Component {
    state = {
        values: [],
    };

    componentDidMount() {
        // Initialize App state after a component mounts successfully
        axios.get('http://localhost:5000/api/values').then((response) => {
            this.setState({
                values: response.data,
            });
        });
    }

    render() {
        return (
            <div>
                <Header as="h2">
                    <Icon name="users" />
                    <Header.Content>Reactivities</Header.Content>
                </Header>
                <List>
                    {this.state.values.map((value: any, index: number) => (
                        <List.Item key={index}>{value.name}</List.Item>
                    ))}
                </List>
            </div>
        );
    }
}
export default App;
