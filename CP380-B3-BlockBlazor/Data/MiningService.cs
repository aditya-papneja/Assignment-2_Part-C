using CP380_B1_BlockList.Models;
using CP380_B3_BlockBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B3_BlockBlazor.Data
{
    public class MiningService
    {
        private readonly BlockService blockService;
        private readonly PendingTransactionService transactionService;

        public MiningService(BlockService blockService,PendingTransactionService transactionService)
        {
            this.blockService = blockService;
            this.transactionService = transactionService;
        }
        public async Task<Block> MineBlock()
        {
            List<BlockSummary> blocks = (List<BlockSummary>)await blockService.GetBlocks();

            var hash = blocks[blocks.Count - 1].Hash;
            var pendPayload =(List<Payload>) await transactionService.GetPayloads();
            Block block= new Block(DateTime.Now, hash,pendPayload);
            block.Mine(2);
            return block;
        }
    }
}
