import { ProdutoForm } from "../components/ProdutoForm";
import { ProdutoList } from "../components/ProdutoList";
import { useProdutos } from "../hooks/useProdutos";

function ProdutosPage() {

  const {
    produtos,
    produtoSelecionado,
    setProdutoSelecionado,

    salvarProduto,
    editarProduto,
    removerProduto
  } = useProdutos();

  return (
    <div>
      <h1>Produtos</h1>

      <ProdutoForm
        produtoSelecionado = { produtoSelecionado }
        onSalvar = { salvarProduto }
        onAtualizar = { editarProduto }
      />

      <hr />

      <ProdutoList
        produtos = { produtos }
        onExcluir = { removerProduto }
        onEditar={ setProdutoSelecionado }
      />
    </div>
  );
}

export default ProdutosPage;