import React from 'react';
import axios from 'axios';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import {Link} from 'react-router-dom';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import styles from './PatientTableCss.css';
 
export default class PatientTable extends React.Component {
constructor(props) {
    super(props);    
    this.state={PatientData:[]};      

    axios.defaults.headers.common['Authorization'] = 
    'Bearer ' + sessionStorage.getItem('token');
        
}
      
componentDidMount() {
    console.log(sessionStorage.getItem("role"));
    axios.get(`patients/`).then(
        response => {
            let patientsData = response.data;
            this.setState({
            PatientData:patientsData
            });
        }
    );
}

render(){
    return (
    <Paper className="PatientTable" elevation={10} Component="div">
      <Typography variant="h5" component="h3"> PATIENTS </Typography>
      <Link to="/patient/add" ><Button className="formButton" variant="contained" fullWidth={true} color = "secondary" style = {{marginBottom:"20px"}}>Add new</Button></Link>
      <TableContainer component={Paper} >
        <Table aria-label="Patients">
          <TableHead>
            <TableRow>
              <TableCell align="left">Lastname</TableCell>
              <TableCell align="left">Firstname</TableCell>
              <TableCell align="left">Clinic name</TableCell>
              <TableCell align="left">Birth date</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {this.state.PatientData.map((row) => (
              <TableRow key={row.patientId}>
                <TableCell align="left"><Link to={"/" + row.patientId}  >{row.patientLastname}</Link></TableCell>
                <TableCell align="left">{row.patientFirstname}</TableCell>
                <TableCell align="left">{row.clinicName}</TableCell>
                <TableCell align="left">{row.birthDate}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Paper>
    );
}
}

