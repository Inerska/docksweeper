import {columns, Container} from "./columns"
import {DataTable} from "./data-table"

async function getData(): Promise<Container[] | null> {
    let data = [];

    try {
        const response = await fetch(`http://localhost:5236/api/v1/DockerContainer?all=true`);
        data = await response.json();
    } catch (err) {
        console.error('Failed to fetch data:', err);
        return null;
    }

    return data;
}

export default async function ContainerDataTableComponent() {
    const data = await getData();

    return <div>
        {
            data
                ? <DataTable columns={columns} data={data}/>
                : <p>No containers found</p>
        }
        
    </div>
}