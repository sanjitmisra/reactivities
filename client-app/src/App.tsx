import React, { Component } from "react";
import logo from "./logo.svg";
import "./App.css";
import { Header, Icon, List, Button } from "semantic-ui-react";
import { cars } from "./demo";
import axios from "axios";

class App extends Component {
  state = {
    values: []
  };

  componentDidMount() {
    axios.get("http://localhost:5000/api/values").then(response => {
      this.setState({
        values: response.data
      });
    });
  }

  
  render() {
    return (
      <div>
        <Header as="h2">
          <Icon name="hand point down outline" />
          <Header.Content>Reactivities</Header.Content>
        </Header>
        <List>
          {this.state.values.map((value: any) => (
            <List.Item key = {value.id}>
              {value.name}
            </List.Item>
          ))}
        </List>
        <Button size="small" color="linkedin">
            <Icon name="download" />
            Save
        </Button>
      </div>
    );
  }
}

export default App;
