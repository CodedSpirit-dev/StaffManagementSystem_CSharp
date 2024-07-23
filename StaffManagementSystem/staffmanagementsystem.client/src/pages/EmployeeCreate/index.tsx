import { useEffect } from "react";
import { FormProvider, useForm } from "react-hook-form";
import { IEmployeeData } from "../../utils/interfaces";
import { optionsDepartment, optionsGender, optionsMaritalStatus, optionsBloodType, optionsStudyGrade } from "../../utils/Dictionaries";
import axios from "axios";

const EmployeeForm = ({ initialData }: { initialData: IEmployeeData | null }) => {
    const methods = useForm<IEmployeeData>({
        defaultValues: initialData ?? {}
    });
    const { register, handleSubmit, setValue, formState: { errors } } = methods;

    useEffect(() => {
        if (initialData) {
            for (const [key, value] of Object.entries(initialData)) {
                if (key === "employmentDetails" && value.hiringDate) {
                    setValue("employmentDetails.hiringDate", value.hiringDate.split('T')[0]); // Convertir la fecha de contratación
                } else {
                    setValue(key as keyof IEmployeeData, value);
                }
            }
        }
    }, [initialData, setValue]);


    const onSubmit = (data: IEmployeeData) => {
        const formattedData = {
            ...data,
            birthDate: new Date(data.birthDate as unknown as string).toISOString().split('T')[0],
            employmentDetails: {
                ...data.employmentDetails,
                hiringDate: new Date(data.employmentDetails.hiringDate).toISOString(),
                resignationDate: data.employmentDetails.resignationDate ? new Date(data.employmentDetails.resignationDate).toISOString() : null,
                isFileComplete: JSON.parse(String(data.employmentDetails.isFileComplete)),
                isActive: true,
                insuranceActive: true,
            }
        };

        if (initialData) {
            axios.patch(`api/Employees/${formattedData.socialSecurityNumber}`, formattedData)
                .then(() => {
                    window.location.href = "/lista";
                })
                .catch(error => {
                    console.error(error.response?.data);
                    console.log(error.response?.status);
                });
        } else {
            axios.post("/api/Employees/", formattedData)
                .then(() => {
                    window.location.href = "/lista";
                })
                .catch(error => {
                    console.error(error.response?.data);
                });
        }
    };


    return (
        <FormProvider {...methods}>
            <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col items-center">
                <div>
                    <h2>Datos Personales</h2>
                    <div className="grid grid-cols-2 gap-4">
                        <div>
                            <label htmlFor="firstName">Nombre</label>
                            <input
                                type="text"
                                id="firstName"
                                className="input_text"
                                {...register("firstName", { required: "Introduce el nombre" })}
                            />
                            {errors.firstName && <p className="error-message">{errors.firstName.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="middleName">Segundo nombre</label>
                            <input
                                type="text"
                                id="middleName"
                                className="input_text"
                                {...register("middleName")}
                            />
                        </div>
                        <div>
                            <label htmlFor="lastName">Apellido</label>
                            <input
                                type="text"
                                id="lastName"
                                className="input_text"
                                {...register("lastName", { required: "No olvides el apellido" })}
                            />
                            {errors.lastName && <p className="error-message">{errors.lastName.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="secondLastname">Segundo apellido</label>
                            <input
                                type="text"
                                id="secondLastname"
                                className="input_text"
                                {...register("secondLastname")}
                            />
                        </div>
                        <div>
                            <label htmlFor="birthDate">Fecha de nacimiento</label>
                            <input
                                type="date"
                                id="birthDate"
                                className="input_date"
                                {...register("birthDate", { required: "La fecha de nacimiento es obligatoria" })}
                            />
                            {errors.birthDate && <p className="error-message">{errors.birthDate.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="gender">Sexo</label>
                            <select
                                id="gender"
                                className="input_text"
                                {...register("gender", { required: "Selecciona el sexo" })}
                            >
                                {optionsGender.map((option) => (
                                    <option key={option.value} value={option.value}>
                                        {option.label}
                                    </option>
                                ))}
                            </select>
                            {errors.gender && <p className="error-message">{errors.gender.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="bloodType">Tipo de sangre</label>
                            <select
                                id="bloodType"
                                className="input_text"
                                {...register("bloodType", { required: "Selecciona el tipo de sangre" })}
                            >
                                {optionsBloodType.map((option) => (
                                    <option key={option.value} value={option.value}>
                                        {option.label}
                                    </option>
                                ))}
                            </select>
                            {errors.bloodType && <p className="error-message">{errors.bloodType.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="maritalStatus">Estado civil</label>
                            <select
                                id="maritalStatus"
                                className="input_text"
                                {...register("maritalStatus", { required: "El estado civil es requerido" })}
                            >
                                {optionsMaritalStatus.map((option) => (
                                    <option key={option.value} value={option.value}>
                                        {option.label}
                                    </option>
                                ))}
                            </select>
                            {errors.maritalStatus && <p className="error-message">{errors.maritalStatus.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="children">Número de hijos</label>
                            <input
                                type="number"
                                id="children"
                                className="input_text"
                                min={0}
                                max={20}
                                defaultValue={0}
                                {...register("children", { required: "El número de hijos no debe estar vacío", min: { value: 0, message: "El número mínimo es 0" }, max: { value: 20, message: "El número máximo es 20" } })}
                            />
                            {errors.children && <p className="error-message">{errors.children.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="studyGrade">Ultimo grado de estudios</label>
                            <select
                                id="studyGrade"
                                className="input_text"
                                {...register("studyGrade", { required: "El ultimo grado de estudios es requerido" })}
                            >
                                {optionsStudyGrade.map((option) => (
                                    <option key={option.value} value={option.value}>
                                        {option.label}
                                    </option>
                                ))}
                            </select>
                            {errors.studyGrade && <p className="error-message">{errors.studyGrade.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="socialSecurityNumber">Número de seguro social</label>
                            <input
                                type="text"
                                id="socialSecurityNumber"
                                className="input_text"
                                {...register("socialSecurityNumber", { required: "Por favor, introduce un número de seguro social." })}
                            />
                            {errors.socialSecurityNumber && <p className="error-message">{errors.socialSecurityNumber.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="rfc">RFC</label>
                            <input
                                type="text"
                                id="rfc"
                                className="input_text"
                                {...register("rfc", { required: "Por favor, introduce un RFC." })}
                            />
                            {errors.rfc && <p className="error-message">{errors.rfc.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="curp">CURP</label>
                            <input
                                type="text"
                                id="curp"
                                className="input_text"
                                {...register("curp", { required: "Por favor, introduce un CURP." })}
                            />
                            {errors.curp && <p className="error-message">{errors.curp.message}</p>}
                        </div>
                    </div>
                    <h2>Datos de contacto</h2>
                    <div className="grid grid-cols-2 gap-4">
                        <div>
                            <label htmlFor="contactInfo.email">Email</label>
                            <input
                                type="email"
                                id="contactInfo.email"
                                className="input_text"
                                {...register("contactInfo.email", { required: "Por favor, introduce un email." })}
                            />
                            {errors.contactInfo?.email && <p className="error-message">{errors.contactInfo.email.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="contactInfo.phoneNumber">Número de teléfono</label>
                            <input
                                type="tel"
                                id="contactInfo.phoneNumber"
                                className="input_text"
                                {...register("contactInfo.phoneNumber", { required: "Por favor, introduce un número de teléfono." })}
                            />
                            {errors.contactInfo?.phoneNumber && <p className="error-message">{errors.contactInfo.phoneNumber.message}</p>}
                        </div>
                    </div>
                    <h2>Dirección</h2>
                    <div className="grid grid-cols-2 gap-4">
                        <div>
                            <label htmlFor="address.street">Calle</label>
                            <input
                                type="text"
                                id="address.street"
                                className="input_text"
                                {...register("address.street", { required: "Por favor, introduce una calle." })}
                            />
                            {errors.address?.street && <p className="error-message">{errors.address.street.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="address.number">Número</label>
                            <input
                                type="text"
                                id="address.number"
                                className="input_text"
                                {...register("address.number", { required: "Por favor, introduce un número." })}
                            />
                            {errors.address?.number && <p className="error-message">{errors.address.number.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="address.suburb">Colonia</label>
                            <input
                                type="text"
                                id="address.suburb"
                                className="input_text"
                                {...register("address.neighborhood", { required: "Por favor, introduce una colonia." })}
                            />
                            {errors.address?.neighborhood && <p className="error-message">{errors.address.neighborhood.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="address.city">Ciudad</label>
                            <input
                                type="text"
                                id="address.city"
                                className="input_text"
                                {...register("address.city", { required: "Por favor, introduce una ciudad." })}
                            />
                            {errors.address?.city && <p className="error-message">{errors.address.city.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="address.state">Estado</label>
                            <input
                                type="text"
                                id="address.state"
                                className="input_text"
                                {...register("address.state", { required: "Por favor, introduce un estado." })}
                            />
                            {errors.address?.state && <p className="error-message">{errors.address.state.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="address.postalCode">Código postal</label>
                            <input
                                type="text"
                                id="address.postalCode"
                                className="input_text"
                                {...register("address.postalCode", { required: "Por favor, introduce un código postal." })}
                            />
                            {errors.address?.postalCode && <p className="error-message">{errors.address.postalCode.message}</p>}
                        </div>
                    </div>
                    <h2>Contacto de emergencia</h2>
                    <div className="grid grid-cols-2 gap-4">
                        <div>
                            <label htmlFor="emergencyContact.fullName">Nombre completo</label>
                            <input
                                type="text"
                                id="emergencyContact.fullName"
                                className="input_text"
                                {...register("emergencyContact.emergencyContactName", { required: "Por favor, introduce un nombre completo." })}
                            />
                            {errors.emergencyContact?.emergencyContactName && <p className="error-message">{errors.emergencyContact.emergencyContactName.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="emergencyContact.relationship">Relación</label>
                            <input
                                type="text"
                                id="emergencyContact.relationship"
                                className="input_text"
                                {...register("emergencyContact.emergencyRelationship", { required: "Por favor, introduce una relación." })}
                            />
                            {errors.emergencyContact?.emergencyRelationship && <p className="error-message">{errors.emergencyContact.emergencyRelationship.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="emergencyContact.phoneNumber">Número de teléfono</label>
                            <input
                                type="tel"
                                id="emergencyContact.phoneNumber"
                                className="input_text"
                                {...register("emergencyContact.emergencyPhone", { required: "Por favor, introduce un número de teléfono." })}
                            />
                            {errors.emergencyContact?.emergencyPhone && <p className="error-message">{errors.emergencyContact.emergencyPhone.message}</p>}
                        </div>
                    </div>
                    <h2>Detalles de empleo</h2>
                    <div className="grid grid-cols-2 gap-4">
                        <div>
                            <label htmlFor="employmentDetails.jobTitle">Título del trabajo</label>
                            <input
                                type="text"
                                id="employmentDetails.jobTitle"
                                className="input_text"
                                {...register("employmentDetails.position", { required: "Por favor, introduce un título de trabajo." })}
                            />
                            {errors.employmentDetails?.position && <p className="error-message">{errors.employmentDetails.position.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="employmentDetails.department">Departamento</label>
                            <select
                                id="employmentDetails.department"
                                className="input_text"
                                {...register("employmentDetails.department", { required: "Selecciona un departamento" })}
                            >
                                {optionsDepartment.map((option) => (
                                    <option key={option.value} value={option.value}>
                                        {option.label}
                                    </option>
                                ))}
                            </select>
                            {errors.employmentDetails?.department && <p className="error-message">{errors.employmentDetails.department.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="employmentDetails.hiringDate">Fecha de contratación</label>
                            <input
                                type="date"
                                id="employmentDetails.hiringDate"
                                className="input_date"
                                {...register("employmentDetails.hiringDate", { required: "Por favor, introduce una fecha de contratación." })}
                            />
                            {errors.employmentDetails?.hiringDate && <p className="error-message">{errors.employmentDetails.hiringDate.message}</p>}
                        </div>
                        <div>
                            <label htmlFor="employmentDetails.resignationDate">Fecha de renuncia</label>
                            <input
                                type="date"
                                id="employmentDetails.resignationDate"
                                className="input_date"
                                {...register("employmentDetails.resignationDate")}
                            />
                        </div>
                        <div>
                            <label htmlFor="employmentDetails.isFileComplete">¿El expediente está completo?</label>
                            <select
                                id="employmentDetails.isFileComplete"
                                className="input_text"
                                {...register("employmentDetails.isFileComplete", { required: "Por favor, selecciona una opción." })}
                            >
                                <option value="true">Sí</option>
                                <option value="false">No</option>
                            </select>
                            {errors.employmentDetails?.isFileComplete && <p className="error-message">{errors.employmentDetails.isFileComplete.message}</p>}
                        </div>
                    </div>
                </div>
                <button type="submit" className="button_blue mt-4">Enviar</button>
            </form>
        </FormProvider>
    );
};

// Componente para la gestión del empleado
const EmployeeManagement = ({ employee }: { employee: IEmployeeData }) => {
    return (
        <div>
            <h1>Gestión de Empleados</h1>
            <EmployeeForm initialData={employee} />
        </div>
    );
};

export default EmployeeManagement;
