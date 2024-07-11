using System.Net.Http.Json;
using StaffTemplate.Shared.Dtos;

public class EmployeeService
{
    private readonly HttpClient _httpClient;

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EmployeeDTO>> GetEmployeesAsync()
    {
        var response = await _httpClient.GetAsync("api/employees");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<EmployeeDTO>>();
    }

    public async Task<EmployeeDTO> CreateEmployeeAsync(EmployeeCreateDTO employee)
    {
        var response = await _httpClient.PostAsJsonAsync("api/employees", employee);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<EmployeeDTO>();
    }
}
