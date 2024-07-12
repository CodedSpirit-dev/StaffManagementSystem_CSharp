import { useEffect, useState } from "react";
import { Link } from "react-router-dom";

interface EmployeeData {
    socialSecurityNumber: number;
    firstName: string;
    lastName: string;
    department: string;
    phoneNumber: string;
}

function EmployeeList() {
    const [employees, setEmployees] = useState<EmployeeData[]>();

    useEffect(() => {
        FetchAllEmployees();
    }, []);

    const contents = employees === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Employee ID</th>
                    <th>Name</th>
                    <th>Department</th>
                    <th>phoneNumber</th>
                </tr>
            </thead>
            <tbody>
                {employees.map(employee =>
                    <tr key={employee.socialSecurityNumber}>
                        <td>{employee.socialSecurityNumber}</td>
                        <td>{employee.firstName}</td>
                        <td>{employee.lastName}</td>
                        <td>{employee.department}</td>
                        <td>{employee.contactInfo.phoneNumber}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Employee List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
            <Link to="/">HOME</Link>
        </div>
    );

    async function FetchAllEmployees() {
        const response = await fetch('api/Employees');
        const data = await response.json();
        setEmployees(data);
    }
}

export default EmployeeList;