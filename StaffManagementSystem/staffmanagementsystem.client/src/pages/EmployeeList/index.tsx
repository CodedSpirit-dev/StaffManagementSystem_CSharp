import { Table, TableBody, TableCell, TableHead, TableHeaderCell, TableRow } from "@tremor/react";
import { useEffect, useState } from "react";
import { EmployeeData } from "../../utils/interfaces";

function EmployeeList({ onEdit }) {
    const [employees, setEmployees] = useState<EmployeeData[]>([]);

    useEffect(() => {
        FetchAllEmployees();
    }, []);

    const contents = employees.length === 0
        ? <p><em>Loading...</em></p>
        : <div className="mx-auto max-w-2xl my-3">
            <Table className="table-auto border border-slate-300 border-opacity-70 divide-tremor-content-emphasis">
                <TableHead>
                    <TableRow>
                        <TableHeaderCell>Identificador</TableHeaderCell>
                        <TableHeaderCell>Nombre</TableHeaderCell>
                        <TableHeaderCell>Apellido</TableHeaderCell>
                        <TableHeaderCell>Numero de telefono</TableHeaderCell>
                        <TableHeaderCell>Departamento</TableHeaderCell>
                        <TableHeaderCell>Activo</TableHeaderCell>
                        <TableHeaderCell>Tiene seguro</TableHeaderCell>
                        <TableHeaderCell>Acciones</TableHeaderCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {employees.map((employee, index) =>
                        <TableRow key={employee.socialSecurityNumber} className={index % 2 === 0 ? 'row-even' : 'row-odd'}>
                            <TableCell className="text-center">{employee.socialSecurityNumber}</TableCell>
                            <TableCell>{employee.firstName}</TableCell>
                            <TableCell>{employee.lastName}</TableCell>
                            <TableCell className="text-center">{employee.contactInfo.phoneNumber}</TableCell>
                            <TableCell>{employee.employmentDetails.department}</TableCell>
                            <TableCell className="text-center">{employee.employmentDetails.isActive ? "Si" : "No"}</TableCell>
                            <TableCell className="text-center">{employee.employmentDetails.insuranceActive ? "Si" : "No"}</TableCell>
                            <TableCell>
                                <button onClick={() => onEdit(employee)}>Editar</button>
                            </TableCell>
                        </TableRow>
                    )}
                </TableBody>
            </Table>
        </div>;

    return (
        <div>
            <h1 className="text-2xl font-extrabold">Employee List</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function FetchAllEmployees() {
        const response = await fetch('api/Employees');
        const data: EmployeeData[] = await response.json();
        setEmployees(data);
    }
}

export default EmployeeList;
