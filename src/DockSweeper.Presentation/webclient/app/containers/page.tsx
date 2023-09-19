import {columns, Container} from "@/app/containers/columns";
import {DataTable} from "@/app/containers/data-table";

async function getData() : Promise<Container[]> {
    const response = await fetch(`http://localhost:5236/api/containers?all=true`, {
        cache: "force-cache",
    });
    
    return await response.json();
}

export default async function ContainerDataTableComponent() {
   
    const data = await getData();
    
    return <div>
        {
            data.length > 0
                ? <DataTable columns={columns} data={data}/>
                : <div>Loading...</div>
        }

    </div>
}