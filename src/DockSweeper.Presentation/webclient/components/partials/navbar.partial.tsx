import Link from "next/link";

export default async function NavbarPartial() {
    return (
        <nav className="flex flex-col">
            <Link href="/">Dashboard</Link>
            <Link href="/containers">Containers</Link>
            <Link href="/images">Images</Link>
            <Link href="/networks">Networks</Link>
            <Link href="/volumes">Volumes</Link>
            <Link href="/tickets">Tickets</Link>
        </nav>
    );
}