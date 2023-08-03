import {columns, Container} from "./columns"
import {DataTable} from "./data-table"

async function getData(): Promise<Container[]> {
    const response = await fetch("http://localhost:5236/api/v1/DockerContainer?all=true");
    return await response.json();
}

export default async function DemoPage() {
    const data = await getData();
    
    return <div> 
        <DataTable columns={columns} data={data}/>
    </div>
}
